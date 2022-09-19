
using Microsoft.AspNetCore.Mvc;

namespace AjratProject.Controllers;

public class AjratController : Controller
{
    public static List<PostNinViewModel> postNins = new List<PostNinViewModel>
    {
        new PostNinViewModel
        {
            Id = 1,
            Name = "bir",
            ImagePath = "farqiyo"
        },
    };

    private readonly ILogger<AjratController> _logger;

    public AjratController(ILogger<AjratController> logger)
    {
        _logger = logger;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<bool> Create(PostNinViewModel postNin,IFormFile upload)
        {     
                if (upload != null && upload.Length > 0)
                {                
                    var fileName = Path.GetFileName(upload.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    postNin.ImagePath = filePath;
                    postNins.Add(postNin);
                    using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileSrteam);
                    }
                    return true;
                }
                return false;
        }
}