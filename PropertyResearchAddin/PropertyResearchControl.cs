using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PropertyResearchAddin.Presentation;

namespace PropertyResearchAddin
{
    public partial class PropertyResearchControl : UserControl
    {
        public PropertyResearchControl()
        {
            InitializeComponent();
            this.elementHost1.Child = new MainWindow();
        }
    }
}
