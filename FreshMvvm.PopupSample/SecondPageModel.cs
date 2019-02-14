using System;
using FreshMvvm.Popups;
using Xamarin.Forms;

namespace FreshMvvm.PopupSample
{
    public class SecondPageModel : FreshBasePageModel
    {
        public Command OpenPopupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPopupPageModel<SamplePopupPageModel>(1);
                });
            }
        }
    }
}
