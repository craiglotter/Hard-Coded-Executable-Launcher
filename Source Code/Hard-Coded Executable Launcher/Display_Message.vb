Public Class Display_Message

    Private CurrentCount As Integer

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
    End Sub

    Private Sub Display_Message_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Message_Textbox.Select(0, 0)

            CurrentCount = Timer1.Interval / 100
            Timer1.Enabled = True
            Timer1.Start()
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Countdown_Label.Text = "Closing in " & (CurrentCount) & " Seconds"
            CurrentCount = CurrentCount - 1
            If CurrentCount < 0 Then
                Me.Close()
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub
End Class