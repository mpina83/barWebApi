
using System;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using ZXing;
using ZXing.Common;
using ZXing.CoreCompat.System.Drawing;
using BarcodeReader = ZXing.BarcodeReader;

namespace BarWebApi.Services
{
    public static class BarcodeUtils
    {
        public static BarcodeModel BarcodeCustomReader()
        {
            Bitmap image;
            try
            {
               // image = (Bitmap) Bitmap.FromFile(uri.LocalPath);
                image = (Bitmap) Bitmap.FromFile("D:\\sample-barcode-image.png");
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Resource not found: " + "D:\\sample-barcode-image.png");
            }
            using(image)
            {

                // create a barcode reader instance
                //IBarcodeReader reader = new BarcodeReader();
        
                BarcodeModel barModel = new BarcodeModel();
                // load a bitmap         
                //var barcodeBitmap = (Bitmap) MediaTypeNames.Image.LoadFrom("C:\\sample-barcode-image.png");
                //var barcodeBitmap = (Bitmap)Image.LoadFrom("C:\\sample-barcode-image.png");
                var barcodeBitmap = (Bitmap) Image.FromFile("D:\\sample-barcode-image.png");
                LuminanceSource source;
                source = new BitmapLuminanceSource(barcodeBitmap);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                // detect and decode the barcode inside the bitmap
         
                // do something with the result
                Result result = new MultiFormatReader().decode(bitmap);
                if (result != null)
                {
                    barModel.TxtDecoderType = result.BarcodeFormat.ToString();
                    barModel.TxtDecoderContent= result.Text;
                }
                return barModel;
            }
        }

        public class BarcodeModel
        {
            public string TxtDecoderType { get; set; }
            public string TxtDecoderContent { get; set; }
        }
    }
}