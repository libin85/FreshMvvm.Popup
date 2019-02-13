# FreshMvvm.Popup
This library adds extension methods to support Popup navigation for Rg.Plugin.Popup from PageModels in FreshMvvm framework.

This libaray uses the original [Rg.Plugins.Popup] library(https://github.com/rotorgames/Rg.Plugins.Popup) and requies you to do all the necessary initalisations to work.

### Setup
1. Reference the library in your Xamarin.Forms project.
2. Install Rg.Plugins.Popup in all the client projects.
3. Init the Rg.Plugins.Popup library in client projects.

Android

    namespace HelloXamarinFormsWorld.Android
    {
        [Activity(Label = "HelloXamarinFormsWorld", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
        public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
        { 
            protected override void OnCreate(Bundle bundle)
            {
              base.OnCreate(bundle);
              Rg.Plugins.Popup.Popup.Init(this, bundle);
              Xamarin.Forms.Forms.Init(this, bundle);
              LoadApplication (new App ());
            }
        }
    }
    
iOS

    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
           Rg.Plugins.Popup.Popup.Init();
           global::Xamarin.Forms.Forms.Init ();
           LoadApplication (new App ());
           return base.FinishedLaunching (app, options);
        }
    }

