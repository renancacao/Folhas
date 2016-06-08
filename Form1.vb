Imports System.IO

Public Class Form1


    Dim pst As String = AppDomain.CurrentDomain.BaseDirectory
    Dim lst As List(Of folha) = Nothing



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False
        lst = New List(Of folha)


        If File.Exists(pst & "\folhas.txt") = False Then

            MsgBox("Arquivo " & pst & "\folhas.txt não encontrado!", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub

        End If

        Using sr As New StreamReader(pst & "\folhas.txt")

            Dim lin As String
            Dim cps() As String
            Dim ctt As Integer = 0

            While sr.EndOfStream = False

                lin = sr.ReadLine
                cps = lin.Split(";")
                ctt += 1

                If cps.Length <> 3 Then
                    MsgBox("Falha na linha " & ctt & "!", MsgBoxStyle.Exclamation)
                    Me.Close()
                    Exit Sub
                End If

                lst.Add(New folha(cps(0), cps(1), cps(2)))

            End While

            sr.Close()

            MsgBox("Foram encontradas " & ctt & " folhas!", MsgBoxStyle.Information)

            lblResult.Text = ""
            txtNumero.Enabled = True
            txtNumero.Focus()

        End Using



    End Sub



    Private Sub txtNumero_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown

        If String.IsNullOrEmpty(txtNumero.Text) Then Exit Sub

        If e.KeyCode = Keys.Enter Then

            lblResult.BackColor = Color.White
            lblResult.Text = ""
            Application.DoEvents()
            Threading.Thread.Sleep(100)


            Dim rlst As List(Of folha) = lst.Where(Function(x) x.Numero = txtNumero.Text).ToList

            If rlst.Count = 0 Then
                lblResult.BackColor = Color.Red
                lblResult.Text = "NÃO ENCONTRADO"

            ElseIf rlst.Count = 1 Then
                lblResult.BackColor = Color.Green
                lblResult.Text = rlst(0).Rota & " - " & rlst(0).Zona

            ElseIf rlst.Count > 1 Then

                lblResult.BackColor = Color.Yellow

                lblResult.Text = "Vários Encontrados" & vbCrLf
                For Each f As folha In rlst
                    lblResult.Text = f.Rota & " - " & f.Zona & vbCrLf
                Next
            End If

            txtNumero.SelectAll()


        End If

    End Sub
End Class
