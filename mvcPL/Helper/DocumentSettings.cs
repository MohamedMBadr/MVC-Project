using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MVC.PL.Helper
{
    public static class DocumentSettings
    {
        public static  string UploadFile(IFormFile file, string folderName)
        {
            //F:\backend\BADR\ASP.NET Core MVC\MVC\BadrMVC\mvcPL\wwwroot\files\
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            string filenName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(folderPath, folderName);

            using  var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);
            return  filenName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files\\" +  folderName);
            if(File.Exists(FilePath))
                 File.Delete(FilePath); 
        }
    }
}
