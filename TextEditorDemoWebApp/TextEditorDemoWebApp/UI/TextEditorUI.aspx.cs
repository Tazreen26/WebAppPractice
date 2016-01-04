using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextEditorDemoWebApp.UI {
    public partial class TextEditorUI : System.Web.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void btnSave_Click(object sender, EventArgs e) {
            lblDisplay.Visible = true;
            RichTextBox.Visible = false;
            lblDisplay.Text = RichTextBox.Text;
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            
        }
    }
}