using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using project_final_6013532.Data;
using project_final_6013532.Models;
using System;
using System.Web;
using System.Net;
using System.Text;
using System.Net.Http;

namespace project_final_6013532.Controllers
{
    public class sendingController : Controller
    {
        private rejectAtsDbContext _context;
        /*private UserManager<User> _userManager;*/

        public sendingController(rejectAtsDbContext context/*, UserManager<User> userManager*/)
        {
            _context = context;
            /* _userManager = userManager;*/

        }//end of function
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _context.rejectAts
                                        .Select(i => new
                                        {
                                            clientRef = i.clientDataId,
                                            refer = i.refCode,
                                            sBank = i.sendingBank,
                                            sBankNo = i.sendingBankNo,
                                            rBank = i.receivingBank,
                                            rBankNo = i.receivingBankNo,
                                            num = i.amount,
                                            statCode = i.statusCode,
                                            stat = i.statusDescription,
                                            tel = i.client.telNo
                                        })
                                        .ToListAsync();
            ViewBag.records = result;
            return View("import");
        }//end of function import that return importview

        [HttpPost]
        public async Task<IActionResult> import(IFormFile file1)
        {
            //empty the table
            _context.rejectAts.RemoveRange(_context.rejectAts);
            await _context.SaveChangesAsync();
            await _context.Database.ExecuteSqlCommandAsync("ALTER TABLE rejectats AUTO_INCREMENT = 1");

            List<RejectAts> list1 = new List<RejectAts>();
            using (var stream = new MemoryStream())
            {
                await file1.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet wk = package.Workbook.Worksheets[0];
                    int rowCount = wk.Dimension.Rows;
                    //loop through all the record or line
                    for (int i = 2; i <= rowCount; i++)
                    {
                        //get value
                        string ref_Code = wk.Cells[i, 1].Value.ToString().Trim();
                        string client_No = wk.Cells[i, 2].Value.ToString().Trim();
                        string sending_Bank = wk.Cells[i, 3].Value.ToString().Trim();
                        string sending_Bank_No = wk.Cells[i, 4].Value.ToString().Trim();
                        string receiving_Bank = wk.Cells[i, 5].Value.ToString().Trim();
                        string receiving_Bank_No = wk.Cells[i, 6].Value.ToString().Trim();
                        string amount = wk.Cells[i, 7].Value.ToString().Trim();
                        string status_Code = wk.Cells[i, 8].Value.ToString().Trim();
                        string status_Description = wk.Cells[i, 9].Value.ToString().Trim();

                        //create object that represent each new record in the table
                        //each of the item must have the same structure as the rejectats model
                        //assining each value into the variable that were declared in the 
                        //data model
                        RejectAts x = new RejectAts()
                        {
                            rejectAtsId = i - 1,
                            refCode = ref_Code,
                            clientDataId = client_No,
                            sendingBank = sending_Bank,
                            sendingBankNo = sending_Bank_No,
                            receivingBank = receiving_Bank,
                            receivingBankNo = receiving_Bank_No,
                            amount = double.Parse(amount),
                            statusCode = status_Code,
                            statusDescription = status_Description,
                        };//end of object
                        list1.Add(x);
                    }//end of for loop
                }//end of inner using

                //add the list1 into the table
                //return Json(list1);

                await _context.rejectAts.AddRangeAsync(list1);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    error = -1,
                    msg = "import succeeded"
                });
            }//end of outter using
        }//end of function import

        [HttpPost]
        public async Task<IActionResult> send_message()
        {
            string username = "ittest2";
            string password = "Password@1";
            string sendername = "Globlex";

            //Byte[] ByteMsg = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(message);

            // Byte[] ByteMsg = To(message);
            // message = HttpUtility.UrlEncode(ByteMsg);

            //String Message = Uri.EscapeUriString(message);
            //string Message = HttpUtility.UrlEncode(ByteMsg);

            // return Json(new {
            //     error = -1,
            //     msg = message,
            // });

            var list1 = await _context.rejectAts
                                        //.Where(s => s.clientDataId == s.client.clientDataId)
                                        .Select(i => new
                                        {
                                            clientRef = i.clientDataId,
                                            refer = i.refCode,
                                            sBank = i.sendingBank,
                                            sBankNo = i.sendingBankNo,
                                            rBank = i.receivingBank,
                                            rBankNo = i.receivingBankNo,
                                            num = i.amount,
                                            statCode = i.statusCode,
                                            stat = i.statusDescription,
                                            tel = i.client.telNo
                                        })
                                        .ToListAsync();
            int counted = list1.Count();

            try
            {
                foreach (var r in list1)
                {
                    string message = r.clientRef + "  " + r.sBank + "  " + r.stat + "  " + r.num;
                    string phonelist = r.tel + ";";

                    Byte[] ByteMsg = To(message);
                    message = HttpUtility.UrlEncode(ByteMsg);

                    string ParamFormat = "?User={0}&Password={1}&Msnlist={2}&Msg={3}&Sender={4}";
                    string Parameters = String.Format(ParamFormat, username, password, phonelist, message, sendername);
                    string API_URL = "http://member.smsmkt.com/SMSLink/SendMsg/index.php";


                    /*WebClient Webc = new WebClient();
                    string result = Webc.DownloadString(API_URL + Parameters);*/
                    string url = API_URL + Parameters;
                    using (HttpClient client = new HttpClient())//using1
                    {
                        using (HttpResponseMessage response = await client.GetAsync(url))//using2
                        {
                            using (HttpContent content = response.Content)//using3
                            {
                                var result = await content.ReadAsStringAsync();

                            }//end of using 3
                        }//end of using2
                    }//end of using1

                }//end of foreach loop
                return Json(new
                {
                    error = 200,
                    msg = "no error with sending message"
                });
            }//end of try

            catch
            {
                return Json(new
                {
                    error = 1,
                    msg = "error",
                });
            }//end of catch
        }//end of send message function

        private byte[] convert(string text)
        {

            //Get the UTF8 encoding
            UTF8Encoding encoder = new System.Text.UTF8Encoding();
            byte[] utf8 = encoder.GetBytes(text);
            //Convert the UTF8 encoding to tis620
            byte[] tis620 = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(874), utf8);
            return tis620;
        }//ef


        //this function is created by someone else
        public byte[] To(string utf8String)
        {
            List<byte> buffer = new List<byte>();
            byte utf8Identifier = 224;
            for (var i = 0; i < utf8String.Length; i++)
            {
                string utf8Char = utf8String.Substring(i, 1);
                byte[] utf8CharBytes = Encoding.UTF8.GetBytes(utf8Char);
                if (utf8CharBytes.Length > 1 && utf8CharBytes[0] == utf8Identifier)
                {
                    var tis620Char = (utf8CharBytes[2] & 0x3F);
                    tis620Char |= ((utf8CharBytes[1] & 0x3F) << 6);
                    tis620Char |= ((utf8CharBytes[0] & 0x0F) << 12);
                    tis620Char -= (0x0E00 + 0xA0);
                    byte tis620Byte = (byte)tis620Char;
                    tis620Byte += 0xA0;
                    tis620Byte += 0xA0; buffer.Add(tis620Byte);
                }
                else
                {
                    buffer.Add(utf8CharBytes[0]);
                }
            }
            return buffer.ToArray();
        }//end of function

    }//end of class
}//end of namespace