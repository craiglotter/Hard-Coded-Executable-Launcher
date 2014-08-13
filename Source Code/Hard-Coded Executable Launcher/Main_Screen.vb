Imports System.IO

Public Class Main_Screen

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            Dim Display_Message1 As New Display_Message()
            Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString
            Display_Message1.Timer1.Interval = 1000
            Display_Message1.ShowDialog()
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim hardcoded_filetolaunch As String = ""

            'hardcoded executable path
            hardcoded_filetolaunch = "G:\bus1010f_g\Your Moves\YourMoves.exe"


            Dim finfo As FileInfo = New FileInfo(hardcoded_filetolaunch)
            If finfo.Exists = True Then
                Label1.Text = "Application Launch Attempt"
                label2.Text = "The application launcher has detected the required executable on this system and is attempting to launch it via a ShellExecute call." & vbCrLf & vbCrLf & "This window should close once the application has launched." & vbCrLf & vbCrLf & "Executable Required: " & vbCrLf & hardcoded_filetolaunch
                Dim procID As Integer = Shell(hardcoded_filetolaunch, AppWinStyle.NormalFocus, False)
                finfo = Nothing
                Me.Close()
            Else
                Label1.Text = "Error: Missing Executable"
                label2.Text = "The application launcher has failed to detect the required executable on this system." & vbCrLf & vbCrLf & "Unfortunately no further actions can be undertaken." & vbCrLf & vbCrLf & "Executable Required: " & vbCrLf & hardcoded_filetolaunch
                finfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Application Launcher")
        End Try
    End Sub
End Class
