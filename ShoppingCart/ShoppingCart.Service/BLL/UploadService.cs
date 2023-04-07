using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Service.BLL
{
    public class UploadService: IUploadService
    {
        private IConfiguration _configuration;

        public UploadService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadPhoto(IFormFile file)
        {
            if (file == null) return string.Empty;

            if (file.Length > 0)
            {
                var container = new BlobContainerClient(_configuration.GetConnectionString("azureBlobStorage"), "upload-container");
                var createResponse = await container.CreateIfNotExistsAsync();

                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                {
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                }

                var blob = container.GetBlobClient(file.FileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                using (var fileStream = file.OpenReadStream())
                {
                    await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                }

                return blob.Uri.ToString();
            }

            return string.Empty;
        }
    }
}
