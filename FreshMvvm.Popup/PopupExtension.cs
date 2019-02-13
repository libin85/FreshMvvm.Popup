using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FreshMvvm.Popups
{
    public static class PopupExtension
    {

        public static  IPageModelCoreMethods PageModelCoreMethods {get;}
        public static async Task PushPopupPageModel<T>(this IPageModelCoreMethods pageModelCoreMethods, object data = null, bool animate = true) where T : FreshBasePageModel
        {
            var pageModel = FreshIOC.Container.Resolve<T>();
            await PushPopupPageModel(pageModel, data, animate);
        }

        public static async Task PushPopupPageModel<T, TPopupPage>(this IPageModelCoreMethods pageModelCoreMethods, object data = null, bool animate = true)
            where T : FreshBasePageModel where TPopupPage : PopupPage
        {
            var pageModel = FreshIOC.Container.Resolve<T>();
            var page = FreshIOC.Container.Resolve<TPopupPage>();
            FreshPageModelResolver.BindingPageModel(data, page, pageModel);
            await PushPopupPageModel(page, animate);
        }

        public static Task PushPopupPageModel(this IPageModelCoreMethods pageModelCoreMethods, Type pageModelType, bool animate = true)
        {
            return PushPopupPageModel(pageModelType, null, animate);
        }

        public static Task PushPopupPageModel( Type pageModelType, object data = null, bool animate = true)
        {
            var pageModel = FreshIOC.Container.Resolve(pageModelType) as FreshBasePageModel;

            return PushPopupPageModel(pageModel, data, animate);
        }

        private static async Task PushPopupPageModel(FreshBasePageModel pageModel, object data = null, bool animate = true)
        {
            var page = FreshPageModelResolver.ResolvePageModel(data, pageModel);
            FreshPageModelResolver.BindingPageModel(data, page, pageModel);

            if (page is PopupPage)
            {
                await PushPopupPageModel((PopupPage)page, animate);
            }
            else
            {
                throw new InvalidOperationException("Resolved page type is not PopupPage");
            }
        }

        private static async Task PushPopupPageModel(PopupPage page, bool animate = true)
        {
            await PopupNavigation.Instance.PushAsync(page, animate);
        }

        public static async Task PopPopupPageModel(this IPageModelCoreMethods pageModelCoreMethods, bool animate = true)
        {
            await PopupNavigation.Instance.PopAsync(animate);
        }

        public static async Task PopAllPopups(this IPageModelCoreMethods pageModelCoreMethods)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}
