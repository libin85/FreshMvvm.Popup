﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FreshMvvm.PopupSample
{
    public class MainPageModel : FreshBasePageModel
    {
       
        public Command OpenSecondPageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<SecondPageModel>();
                });
            }
        }
    }
}
