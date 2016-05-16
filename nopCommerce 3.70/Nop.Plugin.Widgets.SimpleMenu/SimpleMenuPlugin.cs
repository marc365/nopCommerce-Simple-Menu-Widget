using Nop.Core.Domain.Cms;
using Nop.Core.Domain.Logging;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Logging;
using System.Collections.Generic;
using System.Web.Routing;

namespace Nop.Plugin.Widgets.SimpleMenu
{
    public class SimpleMenuPlugin : BasePlugin, IWidgetPlugin
    {
        #region Constructors

        private readonly ISettingService _settingService;
        private readonly ILogger _logger;
        private readonly WidgetSettings _widgetSettings;

        public SimpleMenuPlugin(ISettingService settingService, ILogger logger,
            WidgetSettings widgetSettings)
        {
            this._settingService = settingService;
            this._logger = logger;
            this._widgetSettings = widgetSettings;
        }

        #endregion

        public IList<string> GetWidgetZones()
        {
            return new List<string>       
            {
                "header_menu_before"
            };
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsSimpleMenu";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Widgets.SimpleMenu.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {     
            actionName = "PublicInfo";
            controllerName = "WidgetsSimpleMenu";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "Nop.Plugin.Widgets.SimpleMenu.Controllers"}, {"area", null}, {"widgetZone", widgetZone}
            };
        }

        public override void Install()
        {
            base.Install();

            //mark as active
            _widgetSettings.ActiveWidgetSystemNames.Add("Widgets.SimpleMenu");
            _settingService.SaveSetting(_widgetSettings);

            _logger.InsertLog(LogLevel.Information, "Simple Menu Widget: Installed successfully.");
        }

        public override void Uninstall()
        {
            //mark as disabled
            _widgetSettings.ActiveWidgetSystemNames.Remove("Widgets.SimpleMenu");
            _settingService.SaveSetting(_widgetSettings);

            base.Uninstall();

            _logger.InsertLog(LogLevel.Information, "Simple Menu Widget: Uninstalled successfully.");
        }
    }
}
