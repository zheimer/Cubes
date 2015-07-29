using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostscript.NET;
using System.IO;
using System.Drawing.Imaging;



namespace Application
{
    class PdfConversion
    {
        //Convert a pdf to a jpg image
        public void PDFToImage(string file, int dpi)
        {
            
            Ghostscript.NET.Rasterizer.GhostscriptRasterizer rasterizer = null;
            using (rasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer())
            {
                string pageFilePath = Path.Combine(Path.ChangeExtension(file, ".jpg"));
                if (File.Exists(pageFilePath))
                    return;
                rasterizer.Open(file);
                for (int i = 1; i <= rasterizer.PageCount; i++)
                {
                    using (System.Drawing.Image img = rasterizer.GetPage(dpi, dpi, i))
                    {
                        img.Save(pageFilePath, ImageFormat.Jpeg);
                    }
                }
                rasterizer.Close();
            }
        }
    }
}
