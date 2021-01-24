            [Outlet]
            UIKit.UITextField MyTextfield { get; set; }
     
            [Action ("btnClicked:")]
            partial void btnClicked (Foundation.NSObject sender);
