using System.Windows.Forms;

public class SelectablePictureBox : PictureBox
{
    public SelectablePictureBox()
    {
        this.SetStyle(ControlStyles.Selectable, true);
        this.TabStop = true;
    }
    protected override bool IsInputKey(Keys keyData)
    {
        if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
        {
            return true; // Treat arrow keys as input keys
        }

        return base.IsInputKey(keyData);
    }
}

