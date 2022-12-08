using TEST.DTOs.Requests;

namespace TEST.Services.ServerServices
{
    public interface IUploadServicesServer
    {
        Task<string> UploadFile(UploadFilesRequest request);
        Task<bool> DeleteFile(DeleteFileRequest request);
    }
}
