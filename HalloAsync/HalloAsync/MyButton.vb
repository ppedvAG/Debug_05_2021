Public Class MyButton
    Inherits Button

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)

        'MyBase.OnPaint(pevent)
        'pevent.Graphics.FillRectangle(Brushes.DarkSalmon, ClientRectangle)
        pevent.Graphics.FillRectangle(New SolidBrush(Parent.BackColor), ClientRectangle)
        pevent.Graphics.FillEllipse(Brushes.Aqua, ClientRectangle)

        If ClientRectangle.Contains(PointToClient(MousePosition)) Then

            pevent.Graphics.FillEllipse(Brushes.HotPink, ClientRectangle)

        End If
        Dim sf = New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        pevent.Graphics.DrawString("klick mich", SystemFonts.DefaultFont, Brushes.Lime, ClientRectangle, sf)

    End Sub

End Class
