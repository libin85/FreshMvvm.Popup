using FreshMvvm.Popups;
using Xamarin.Forms;

namespace FreshMvvm.PopupSample
{
    public class SamplePopupPageModel : FreshBasePageModel
    {
        public override void Init(object initData)
        {
            base.Init(initData);
            var count = (int)initData;
        }

        public Command ClosePopupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PopPopupPageModel();
                    await CoreMethods.PopToRoot(false);
                });
            }
        }
    }
}
