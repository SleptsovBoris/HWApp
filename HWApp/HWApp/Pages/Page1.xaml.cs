using HWApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HWApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Page1 : ContentPage
    {
        private Page1ViewModel vm = new Page1ViewModel();
        public Page1()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}