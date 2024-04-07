using CommercialWebsite.DataContext.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CommercialWebsite.Application.Pages;

public class IndexModel : PageModel
{
    private readonly IWebsiteFieldRepository _websiteFieldRepository;
    private readonly IClientRepository _clientRepository;

    public IndexModel(
        IWebsiteFieldRepository websiteFieldRepository,
        IClientRepository clientRepository)
    {
        this._websiteFieldRepository = websiteFieldRepository;
        this._clientRepository = clientRepository;
    }

    public void OnGet()
    {
        string lang = this.Request.Query["lang"].FirstOrDefault() ?? "tr";

        ViewData["HomeMenuText"] = this._websiteFieldRepository.GetTextByNameAndLang("menu__home", lang);
        ViewData["ClientsMenuText"] = this._websiteFieldRepository.GetTextByNameAndLang("menu__clients", lang);
        ViewData["ClientsTitleText"] = this._websiteFieldRepository.GetTextByNameAndLang("page_clients__title", lang);
        ViewData["AllSectionText"] = this._websiteFieldRepository.GetTextByNameAndLang("page_clients__section_all", lang);
        ViewData["WebsitesSectionText"] = this._websiteFieldRepository.GetTextByNameAndLang("page_clients__section_websites", lang);
        ViewData["SoftwareSectionText"] = this._websiteFieldRepository.GetTextByNameAndLang("page_clients__section_software", lang);
        ViewData["UiuxSectionText"] = this._websiteFieldRepository.GetTextByNameAndLang("page_clients__section_ui_ux", lang);
        ViewData["ECommerceSectionText"] = this._websiteFieldRepository.GetTextByNameAndLang("page_clients__section_e_commerce", lang);

        ViewData["Clients"] = this._clientRepository.GetAll();
    }
}
