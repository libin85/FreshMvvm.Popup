using System;
using System.Windows.Input;
using FreshMvvm.Popups;
using Xamarin.Forms;

namespace FreshMvvm.PopupSample
{
    public class MainPageModel : FreshBasePageModel
    {
       
        public Command OpenPopupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPopupPageModel<SamplePopupPageModel>();
                });
            }
        }
    }
}
