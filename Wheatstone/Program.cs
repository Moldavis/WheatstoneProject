using System.Windows.Forms;

namespace Wheatstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var form = new GUI();
            form.AcceptButton = new Button();
            form.ShowDialog();
        }
    }
}
