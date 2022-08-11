using Microsoft.AspNetCore.Http;
using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public class LocalStorageImageRepository: IImageRepository
    {
        private readonly StudentAdminContext context;

        public LocalStorageImageRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        public async Task<String> UploadImage(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"Resourses\Images",fileName);
            using Stream fileStream = new FileStream(fileName, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerRelativePath(fileName);
        }

        private String GetServerRelativePath(String fileName)
        {
            return Path.Combine(@"Resourses\Images", fileName);
        }
    }
}
