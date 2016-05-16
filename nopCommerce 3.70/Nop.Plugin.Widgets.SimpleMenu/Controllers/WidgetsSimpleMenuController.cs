using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Stores;
using Nop.Plugin.Misc.ContentManagement;
using Nop.Plugin.Misc.ContentManagement.Domain;
using Nop.Plugin.Misc.ContentManagement.Services;
using Nop.Web.Controllers;
using Nop.Web.Framework.Controllers;
using System.Web.Mvc;

namespace Nop.Plugin.Widgets.SimpleMenu.Controllers
{
    public class WidgetsSimpleMenuController : BasePublicController
    {
        private readonly ContentManagementSettings _contentmanagementSettings;
        private readonly IRepository<Page> _pagesRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStoreContext _storeContext;

        public WidgetsSimpleMenuController(ContentManagementSettings contentmanagementSettings, IRepository<Page> pagesRepository,
            IRepository<StoreMapping> storeMappingRepository, IStoreContext storeContext)
        {
            this._contentmanagementSettings = contentmanagementSettings;
            this._pagesRepository = pagesRepository;
            this._storeMappingRepository = storeMappingRepository;
            this._storeContext = storeContext;
        }

        ContentManagementService _contentmanagementService = new ContentManagementService();

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            return View("~/Plugins/Widgets.SimpleMenu/Views/WidgetsSimpleMenu/Configure.cshtml");
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, string theme)
        {
            return View("~/Plugins/Widgets.SimpleMenu/Views/WidgetsSimpleMenu/PublicInfo.cshtml");
        }

    }

}
