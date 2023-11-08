Imports QRCoder
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Module Module1
    Sub Main()
        ' Dynamic text to be encoded as a QR code
        Dim Text As String = "003926 2X7 In M W                  MA,Q,1,BL,83.28125,BW,25.53125,PL,82.15625,PW,23.96875,GA,0,GL,1,LB,2,TB,1,FS,2,AS,2,R7,81.84375,18.71875,R7,18.53125,23.84375,R7,64.78125,23.84375,L7,1.4375,6.8125,L2,83.3125,0.1875,R2,83.3125,25.34375,R2,-0.03125,25.34375,L2,-0.03125,0.1875" ' Replace with your desired text

        ' Extract the first 6 digits of the part number from the text
        Dim first6Digits As String = Text.Substring(0, Math.Min(6, Text.Length))

        ' Generate QRCode From Text
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(Text, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)
        Dim qrCodeImage As Bitmap = qrCode.GetGraphic(8)

        ' Specify the directory where you want to save the QR code
        Dim saveDirectory As String = "M:\Metal Codes\Console QR"

        ' Check if the directory exists; if not, create it
        If Not Directory.Exists(saveDirectory) Then
            Directory.CreateDirectory(saveDirectory)
        End If

        ' Save the QR code with the first 6 digits of the text as the filename
        Dim savePath As String = Path.Combine(saveDirectory, first6Digits & ".png")
        qrCodeImage.Save(savePath, ImageFormat.Png)

        ' Display a message indicating the QR code was saved
        Console.WriteLine("QR code saved to: " & savePath)

        ' Wait for user to close
        Console.ReadLine()
    End Sub
End Module