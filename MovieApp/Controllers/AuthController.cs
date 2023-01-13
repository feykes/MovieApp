using Azure.Messaging;
using Entities.Models;
using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<AppUser> _userManager { get; set; }
        public SignInManager<AppUser> _signInManager { get; set; }
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok("Kullanıcı Başarılı bir şekilde oluşturuldu!" + model);
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        return BadRequest("Kullanıcı oluşturulurken bir hata ile karşılaşıldı!");
                    }
                }
            }

            return Ok();
        }
        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız bir süreliğine kilitlenmiştir! Lütfen daha sonra tekrar deneyiniz!");
                        return Ok(model);
                    }
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        return Ok();
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user);
                        int fail = await _userManager.GetAccessFailedCountAsync(user);
                        ModelState.AddModelError("", $"{fail} kez başarısız giriş.");
                        if (fail == 2)
                        {
                            ModelState.AddModelError("", $"{fail} kez giriş yaptınız. Son hakkınız!");
                        }
                        if (fail == 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(5)));
                            ModelState.AddModelError("", "Hesabınız 3 başarısız girişten dolayı 5 dk süreyle kitlenmiştir. Lütfen daha sonra tekrar deneyiniz.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email adresiniz veya şifreniz yanlış!");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamamıştır.");
                }
            }
            return Ok(model);
        }
    }

}