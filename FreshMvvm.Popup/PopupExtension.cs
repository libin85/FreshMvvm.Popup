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
            await PushPageModel(pageModel, data, animate);
        }

        public static async Task PushPopupPageModel<T, TPopupPage>(this IPageModelCoreMethods pageModelCoreMethods, object data = null, bool animate = true)
            where T : FreshBasePageModel where TPopupPage : PopupPage
        {
            var pageModel = FreshIOC.Container.Resolve<T>();
            var page = FreshIOC.Container.Resolve<TPopupPage>();
            FreshPageModelResolver.BindingPageModel(data, page, pageModel);
            await PushPageModelWithPage(page, animate);
        }

        public static Task PushPageModel(this IPageModelCoreMethods pageModelCoreMethods, Type pageModelType, bool animate = true)
        {
            return PushPageModel(pageModelType, null, animate);
        }

        public static Task PushPageModel( Type pageModelType, object data = null, bool animate = true)
        {
            var pageModel = FreshIOC.Container.Resolve(pageModelType) as FreshBasePageModel;

            return PushPageModel(pageModel, data, animate);
        }

        private static async Task PushPageModel(FreshBasePageModel pageModel, object data = null, bool animate = true)
        {
            var page = FreshPageModelResolver.ResolvePageModel(data, pageModel);
            FreshPageModelResolver.BindingPageModel(data, page, pageModel);

            if (page is PopupPage)
                await PushPageModelWithPage((PopupPage)page, animate);
            else
                throw new InvalidOperationException("Resolved page type is not PopupPage");
        }

        private static async Task PushPageModelWithPage(PopupPage page, bool animate = true)
        {
            await PopupNavigation.Instance.PushAsync(page, animate);
        }

        public static async Task PopPageModel(this IPageModelCoreMethods pageModelCoreMethods, bool animate = true)
        {
            await PopupNavigation.Instance.PopAsync(animate);
        }

        public static async Task PopAll(this IPageModelCoreMethods pageModelCoreMethods)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}
