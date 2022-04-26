
namespace Client
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.SendButton = new System.Windows.Forms.Button();
      this.OutputTextField = new System.Windows.Forms.RichTextBox();
      this.InputTextField = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // SendButton
      // 
      this.SendButton.BackColor = System.Drawing.SystemColors.ControlText;
      this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SendButton.Font = new System.Drawing.Font("MV Boli", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SendButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
      this.SendButton.Location = new System.Drawing.Point(12, 325);
      this.SendButton.Name = "SendButton";
      this.SendButton.Size = new System.Drawing.Size(453, 113);
      this.SendButton.TabIndex = 0;
      this.SendButton.Text = "Send";
      this.SendButton.UseVisualStyleBackColor = false;
      this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
      // 
      // OutputTextField
      // 
      this.OutputTextField.Location = new System.Drawing.Point(487, 12);
      this.OutputTextField.Name = "OutputTextField";
      this.OutputTextField.Size = new System.Drawing.Size(301, 426);
      this.OutputTextField.TabIndex = 3;
      this.OutputTextField.Text = "";
      // 
      // InputTextField
      // 
      this.InputTextField.Location = new System.Drawing.Point(12, 12);
      this.InputTextField.Name = "InputTextField";
      this.InputTextField.Size = new System.Drawing.Size(453, 307);
      this.InputTextField.TabIndex = 4;
      this.InputTextField.Text = "";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.InputTextField);
      this.Controls.Add(this.OutputTextField);
      this.Controls.Add(this.SendButton);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button SendButton;
    private System.Windows.Forms.RichTextBox OutputTextField;
    private System.Windows.Forms.RichTextBox InputTextField;
  }
}

