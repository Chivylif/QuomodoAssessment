using TEST.DTOs.Requests;
using TEST.DTOs.Response;
using TEST.Models;
using System.IO;

namespace TEST.Services.ServerServices
{
    public class FolderServicesServer : IFolderServicesServer
    {
        private readonly IWebHostEnvironment _env;
        private string _rootPath;
        public FolderServicesServer(IWebHostEnvironment env)
        {
            _env = env;
            _rootPath = _env.WebRootPath;
        }

        public Task<bool> CreateFolder(string folderName)
        {
            var path = _rootPath + "/" + folderName;

            if (!Directory.Exists(path))
            {
                var res = Directory.CreateDirectory(path);
                if (res.Exists)
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            else
            {
                throw new Exception("Folder already exists");
            }
        }

        public Task<bool> CreateSubFolder(CreateSubFolderRequest request)
        {
            var path = _rootPath + "/" + request.ParentFolderPath + "/" + request.Name;

            if (!Directory.Exists(path))
            {
                var res = Directory.CreateDirectory(path);
                if (res.Exists)
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            else
            {
                throw new Exception("Folder already exists");
            }
        }

        public Task<bool> DeleteFolder(DeleteFolderRequest request)
        {
            var path = String.Empty;
            
            path = request.ParentFolderPath == null ? _rootPath + "/" + request.Name : _rootPath + "/" + request.ParentFolderPath + "/" + request.Name;

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("Folder does not exist");
            }
        }

        public Task<GetFolderContentResponse> GetFolderContents(GetFolderContentsRequest request)
        {
            var path = _rootPath + "/" + request.FolderPath;
            var res = new GetFolderContentResponse();

            if (Directory.Exists(path))
            {
                var filePaths = Directory.GetFiles(path).ToList();
                var folderPaths = Directory.GetDirectories(path).ToList();
                var files = new List<string>();
                
                if (filePaths.Count > 0 || folderPaths.Count > 0)
                {
                    foreach (var file in filePaths)
                    {
                        files.Add(Path.GetFileName(file));
                    }

                    var folders = new List<string>();
                    foreach (var f in folderPaths)
                    {
                        folders.Add(Path.GetFileName(f));
                    }

                    var folder = "";
                    if (request.FolderPath.Contains("/"))
                    {
                        folder = request.FolderPath.Substring(request.FolderPath.LastIndexOf("/") + 1);
                    }
                    else
                    {
                        folder = request.FolderPath;
                    }

                    res.Folder = folder;
                    res.Files = files;
                    res.SubFolders = folders;
                    res.FolderCount = folders.Count;
                    res.FileCount = files.Count;
                }
                else
                {
                    throw new Exception("Folder is empty");
                }

            }
            else
            {
                return request.FolderId < 0 ? throw new Exception("Folder does not exist") : Task.FromResult(res);
            }

            return Task.FromResult(res);
        }
        public Task<bool> RenameFolder(RenameFolderRequest request)
        {
            var result = true;
            
            var oldPath = _rootPath + "/" + request.ParentFolderPath + "/" + request.OldName;
            var newPath = _rootPath + "/" +request.ParentFolderPath + "/" + request.NewName;

            Directory.Move(oldPath, newPath);
            if (Directory.Exists(oldPath))
            {
                result = false;
                throw new Exception("Folder could not be renamed");
            }

            return Task.FromResult(result);
        }
    }
}
