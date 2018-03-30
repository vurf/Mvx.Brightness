using BrightnessSample.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace BrightnessSample.iOS.Views
{
    public partial class MyViewController : MvxViewController<MainViewModel>
    {
        public MyViewController() : base("MyViewController", null)
        {
        }

        [Outlet]
        public UIButton Bright { get; set; }

        [Outlet]
        public UIButton ReturnBright { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var bindingSet = this.CreateBindingSet<MyViewController, MainViewModel>();
            bindingSet.Bind(this.Bright).To(vm => vm.MakeBrightCommand);
            bindingSet.Bind(this.ReturnBright).To(vm => vm.ReturnBrightCommand);
            bindingSet.Apply();
        }
    }
}