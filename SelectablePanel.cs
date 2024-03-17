using System.Windows.Forms;

    public class SelectablePanel : Panel
{
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
        {
            return true; // Prevent further processing of arrow key events
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }
}


