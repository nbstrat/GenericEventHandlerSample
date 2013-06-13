Public Class Form1

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

        'misc positioning values - ignore 
        Dim H As Integer = 25
        Dim W As Integer = 75
        Dim Padding As Integer = 25
        Dim StartX As Integer = 86
        Dim StartY As Integer = 50 + H
        Dim StartPoint = New System.Drawing.Point(StartX, StartY)
        Dim defaultFont As Font = New System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        
        'create a new button
        Dim btnClickButton As Button = New Button
        With btnClickButton
            .Name = "btnClickMe"
            .Location = StartPoint
            .AutoSize = True
            .Font = defaultFont
            .Text = "1"
        End With

        'add button to the form
        Me.Controls.Add(btnClickButton)

        ' hook the button to a generic event handler
        AddHandler btnClickButton.Click, AddressOf ButtonClickEvent

        'apply the offset to positioning the next button just below the first
        StartPoint.Offset(0, H + Padding)

        'create a second button that will toggle the display of the first button
        Dim btnClickButton2 As Button = New Button
        With btnClickButton2
            .Name = "btnToggle"
            .Location = StartPoint
            .AutoSize = True
            .Font = defaultFont
            .Text = "2"
        End With

        'add button to the form
        Me.Controls.Add(btnClickButton2)

        ' hook the button to a generic event handler
        AddHandler btnClickButton2.Click, AddressOf ButtonClickEvent

        ' !!!! you are not limited to click events !!! 
        'AddHandler btnClickButton2.VisibleChanged, AddressOf btnVisibleChanged


    End Sub


    'generic button click event"
    Private Sub ButtonClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim list As New List(Of Control)()
        GetAllControl(Me, list)

        For Each control As Control In list
            If control.[GetType]() = GetType(Button) Then

                If sender.Equals(control) Then
                    MsgBox("You clicked button " & control.Name & " - the " & control.Text & " button.")
                End If
            End If
        Next
    End Sub

    'returns a list of controls within the specified control
    Private Sub GetAllControl(c As Control, list As List(Of Control))
        For Each control As Control In c.Controls
            list.Add(control)

            If control.[GetType]() = GetType(Panel) Then
                GetAllControl(control, list)
            End If
        Next
    End Sub
End Class
