using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LanguageNew.Services
{
    public class ImageServices
    {
        public static string GetImageDataURL(HttpPostedFileBase imgFile)
        {
            StringBuilder Container = new StringBuilder();
            Container.Append("<img src=\"data:image/");
            Container.Append(Path.GetExtension(imgFile.FileName).Replace(".", ""));
            Container.Append(";base64,");
        //    Container



                return "";
                       
    }
}