using System.IO;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using Gma.QrCodeNet.Encoding;
using iTextSharp.text.pdf.qrcode;

namespace QRProject.Controllers
{
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            Random r = new Random();
            int number = r.Next(10, 10000);

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(number.ToString(), QRCodeGenerator.ECCLevel.H);
            QRCode qRCode = new QRCode(qRCodeData);


            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bitmap = QrCode.GetGraphic(200))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                } 
            }
            return View();
        }
    }
}
