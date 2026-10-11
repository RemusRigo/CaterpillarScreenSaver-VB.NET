'--------------------------------------------------------------------------------------------------
' user32.dll Functions for formanaging windows, handling input, and other core user interface tasks.
'
'   © 2026 Remus Rigo
'      v1.0.20261009
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices
Imports System.Text

Namespace API
   Module user32

      Friend ReadOnly HWND_BOTTOM As New IntPtr(1)

      Friend Const GW_CHILD As UInteger = 5
      Friend Const GW_HWNDNEXT As UInteger = 2

      Friend Delegate Function EnumWindowsProc(hwnd As IntPtr, lParam As IntPtr) As Boolean

      '-----------------------------------------------------------------------------------------------
      ' Structures

      <StructLayout(LayoutKind.Sequential)>
      Friend Structure AccentPolicy
         Public AccentState As Integer
         Public AccentFlags As Integer
         Public GradientColor As Integer
         Public AnimationId As Integer
      End Structure

      <StructLayout(LayoutKind.Sequential)>
      Friend Structure BLENDFUNCTION
         Public BlendOp As Byte
         Public BlendFlags As Byte
         Public SourceConstantAlpha As Byte
         Public AlphaFormat As Byte
      End Structure

      <StructLayout(LayoutKind.Sequential)>
      Friend Structure GDI_POINT
         Public X As Integer
         Public Y As Integer
         Sub New(x As Integer, y As Integer)
            Me.X = x : Me.Y = y
         End Sub
      End Structure

      <StructLayout(LayoutKind.Sequential)>
      Friend Structure GDI_SIZE
         Public Width As Integer
         Public Height As Integer
         Sub New(w As Integer, h As Integer)
            Width = w : Height = h
         End Sub
      End Structure

      <StructLayout(LayoutKind.Sequential)>
      Friend Structure RECT
         Public Left As Integer
         Public Top As Integer
         Public Right As Integer
         Public Bottom As Integer
      End Structure

      <StructLayout(LayoutKind.Sequential)>
      Friend Structure WindowCompositionAttributeData
         Public Attribute As Integer
         Public Data As IntPtr
         Public SizeOfData As Integer
      End Structure

      '-----------------------------------------------------------------------------------------------
      ' Functions

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function AppendMenu(hMenu As IntPtr, uFlags As UInteger, uIDNewItem As UInteger, lpNewItem As String) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function CloseDesktop(hDesktop As IntPtr) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function EnumWindows(lpEnumFunc As EnumWindowsProc, lParam As IntPtr) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function FindWindowEx(hWndParent As IntPtr, hWndChildAfter As IntPtr, lpszClass As String, lpszWindow As String) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetClassName(hWnd As IntPtr, lpClassName As StringBuilder, nMaxCount As Integer) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetClientRect(hWnd As IntPtr, ByRef lpRect As RECT) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function

      <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetCurrentThreadId() As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetDC(hwnd As IntPtr) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetSystemMenu(hWnd As IntPtr, bRevert As Boolean) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetThreadDesktop(threadId As Integer) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
      Public Function GetUserObjectInformation(hObj As IntPtr, nIndex As Integer, pvInfo As StringBuilder, nLength As Integer, ByRef lpnLengthNeeded As Integer) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetWindow(hWnd As IntPtr, uCmd As UInteger) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetWindowRect(hWnd As IntPtr, ByRef rect As RECT) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetWindowText(hWnd As IntPtr, lpString As System.Text.StringBuilder, nMaxCount As Integer) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetWindowTextLength(hWnd As IntPtr) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As UInteger) As UInteger
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function IsWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function IsWindowVisible(hWnd As IntPtr) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function OpenDesktop(name As String, flags As Integer, inherit As Boolean, access As UInteger) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function ReleaseDC(hwnd As IntPtr, hDC As IntPtr) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SendMessage(hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetLayeredWindowAttributes(hWnd As IntPtr, crKey As UInteger, bAlpha As Byte, dwFlags As UInteger) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetParent(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetProcessDPIAware() As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetThreadDesktop(hDesktop As IntPtr) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetWindowCompositionAttribute(hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetWindowLong(hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer, uFlags As UInteger) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
      Public Function SystemParametersInfo(uiAction As UInteger, uiParam As UInteger, pvParam As StringBuilder, fWinIni As UInteger) As Boolean
      End Function

      <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
      Public Function UpdateLayeredWindow(hwnd As IntPtr, hdcDst As IntPtr, ByRef pptDst As GDI_POINT, ByRef psize As GDI_SIZE, hdcSrc As IntPtr,
                                          ByRef pptSrc As GDI_POINT, crKey As UInteger, ByRef pblend As BLENDFUNCTION, dwFlags As UInteger) As Boolean
      End Function

   End Module

End Namespace