using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace X
{
    public static class FormExtensions
    {
        

        public static void EnableButton(object buttonSender)
        {
            if (buttonSender is Button)
            {
                ((Button)buttonSender).Enabled = true;
            }
        }
        public static void DisableButton(object buttonSender)
        {
            if (buttonSender is Button)
            {
                ((Button)buttonSender).Enabled = false;
            }
        }
    }
}
