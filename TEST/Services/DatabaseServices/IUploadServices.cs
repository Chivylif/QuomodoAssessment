using TEST.DTOs.Requests;
using TEST.Models;

namespace TEST.Services.DatabaseServices
{
    public interface IUploadServices
    {
        Task<Upload> UploadFile(UploadFilesRequest request, string url);
        Task<bool> DeleteFile(DeleteFileRequest request);
        Task<IEnumerable<Upload>> GetAllFiles();
    }
}
