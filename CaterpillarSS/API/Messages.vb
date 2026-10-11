'--------------------------------------------------------------------------------------------------
' Messages - Constants for Windows messages
'   © 2026 Remus Rigo
'      v1.0 2026-06-11
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Namespace API
   Module Messages

      '--------------------------------------------------------------------------------------------------
      ' ListView Hit Test codes
      Public Const LVHT_NOWHERE As Integer = &H1
      Public Const LVHT_ONITEMICON As Integer = &H2
      Public Const LVHT_ONITEMLABEL As Integer = &H4
      Public Const LVHT_ONITEMSTATEICON As Integer = &H8
      Public Const LVHT_ABOVE As Integer = &H10
      Public Const LVHT_BELOW As Integer = &H20
      Public Const LVHT_TOLEFT As Integer = &H40
      Public Const LVHT_TORIGHT As Integer = &H80
      Public Const LVHT_ONITEM As Integer = LVHT_ONITEMICON Or LVHT_ONITEMLABEL Or LVHT_ONITEMSTATEICON

      '--------------------------------------------------------------------------------------------------
      ' ListView Item Rect
      Public Const LVIR_BOUNDS As Integer = 0
      Public Const LVIR_ICON As Integer = 1
      Public Const LVIR_LABEL As Integer = 2
      Public Const LVIR_SELECTBOUNDS As Integer = 3

      '--------------------------------------------------------------------------------------------------
      ' ListView Item Flag
      Public Const LVIF_TEXT As Integer = &H1
      Public Const LVIF_IMAGE As Integer = &H2
      Public Const LVIF_PARAM As Integer = &H4
      Public Const LVIF_STATE As Integer = &H8
      Public Const LVIF_INDENT As Integer = &H10
      Public Const LVIF_GROUPID As Integer = &H100
      Public Const LVIF_COLUMNS As Integer = &H200
      Public Const LVIF_NORECOMPUTE As Integer = &H800

      '--------------------------------------------------------------------------------------------------
      ' ListView Item State
      Public Const LVIS_FOCUSED As Integer = &H1
      Public Const LVIS_SELECTED As Integer = &H2
      Public Const LVIS_CUT As Integer = &H4
      Public Const LVIS_DROPHILITED As Integer = &H8
      Public Const LVIS_OVERLAYMASK As Integer = &HF00
      Public Const LVIS_STATEIMAGEMASK As Integer = &HF000

      '--------------------------------------------------------------------------------------------------
      ' ListView Messages
      Public Const LVM_FIRST As UInteger = &H1000 ' First
      Public Const LVM_GETITEMCOUNT As UInteger = &H1004 ' Returns total item count
      Public Const LVM_GETITEM As UInteger = &H104B ' Gets item attributes
      Public Const LVM_SETITEM As UInteger = &H104C ' Sets item attributes
      Public Const LVM_INSERTITEM As UInteger = &H104D ' Inserts a new item
      Public Const LVM_DELETEITEM As UInteger = &H1008 ' Deletes an item
      Public Const LVM_DELETEALLITEMS As UInteger = &H1009 ' Deletes all items
      Public Const LVM_GETITEMRECT As UInteger = &H100E ' Gets item bounding rect
      Public Const LVM_GETNEXTITEM As UInteger = &H100C ' Finds next item matching flags
      Public Const LVM_HITTEST As UInteger = &H1012 ' Tests which item is at a point
      Public Const LVM_ENSUREVISIBLE As UInteger = &H1013 ' Scrolls item into view
      Public Const LVM_SCROLL As UInteger = &H1014 ' Scrolls the list
      Public Const LVM_REDRAWITEMS As UInteger = &H1015 ' Invalidates a range of items
      Public Const LVM_ARRANGE As UInteger = &H1016 ' Arranges icons
      Public Const LVM_GETEDITCONTROL As UInteger = &H1018 ' Gets the label-edit control
      Public Const LVM_DELETECOLUMN As UInteger = &H101C ' Deletes a column
      Public Const LVM_GETCOLUMNWIDTH As UInteger = &H101D ' Gets column width
      Public Const LVM_SETCOLUMNWIDTH As UInteger = &H101E ' Sets column width
      Public Const LVM_GETHEADER As UInteger = &H101F ' Gets the header control handle
      Public Const LVM_GETVIEWRECT As UInteger = &H1022 ' Gets the bounding rect of all items
      Public Const LVM_GETITEMSTATE As UInteger = &H102C ' Gets item state bits
      Public Const LVM_SETITEMSTATE As UInteger = &H102B ' Sets item state bits
      Public Const LVM_SETEXTENDEDLISTVIEWSTYLE As UInteger = &H1036 ' Sets extended styles
      Public Const LVM_GETEXTENDEDLISTVIEWSTYLE As UInteger = &H1037 ' Gets extended styles
      Public Const LVM_GETSUBITEMRECT As UInteger = &H1038 ' Gets subitem bounding rect
      Public Const LVM_GETSELECTEDCOUNT As UInteger = &H1032 ' Returns selected item count
      Public Const LVM_GETCOLUMN As UInteger = &H105F ' Gets column attributes
      Public Const LVM_SETCOLUMN As UInteger = &H1060 ' Sets column attributes
      Public Const LVM_INSERTCOLUMN As UInteger = &H1061 ' Inserts a column
      Public Const LVM_GETITEMTEXT As UInteger = &H1073 ' Gets item/subitem text
      Public Const LVM_SETITEMTEXT As UInteger = &H1074 ' Sets item/subitem text
      Public Const LVM_EDITLABEL As UInteger = &H1076 ' Starts in-place label editing

      '--------------------------------------------------------------------------------------------------
      ' ListView Notifications
      Public Const LVN_ITEMCHANGING As Integer = -100 ' Before an item attribute changes
      Public Const LVN_ITEMCHANGED As Integer = -101 ' After an item attribute changes
      Public Const LVN_INSERTITEM As Integer = -102 ' An item was inserted
      Public Const LVN_DELETEITEM As Integer = -103 ' An item was deleted
      Public Const LVN_DELETEALLITEMS As Integer = -104 ' All items were deleted
      Public Const LVN_COLUMNCLICK As Integer = -108 ' A column header was clicked
      Public Const LVN_BEGINDRAG As Integer = -109 ' Left-button drag started
      Public Const LVN_BEGINRDRAG As Integer = -111 ' Right-button drag started
      Public Const LVN_ITEMACTIVATE As Integer = -114 ' Item was activated (double-click/Enter)
      Public Const LVN_ODSTATECHANGED As Integer = -115 ' Range of owner-data items changed state
      Public Const LVN_HOTTRACK As Integer = -121 ' Mouse moved over an item
      Public Const LVN_KEYDOWN As Integer = -155 ' Key was pressed
      Public Const LVN_MARQUEEBEGIN As Integer = -156 ' Rubber-band selection started
      Public Const LVN_GETDISPINFO As Integer = -177 ' Control needs item text/image (callback)
      Public Const LVN_SETDISPINFO As Integer = -178 ' Item text was edited (callback)
      Public Const LVN_ODFINDITEM As Integer = -179 ' Owner-data search requested
      Public Const LVN_GETINFOTIP As Integer = -158 ' Tooltip text needed
      Public Const LVN_INCREMENTALSEARCH As Integer = -163 ' Incremental keyboard search started

      '--------------------------------------------------------------------------------------------------
      ' ListView Next Item flags
      Public Const LVNI_ALL As Integer = 0
      Public Const LVNI_FOCUSED As Integer = 1
      Public Const LVNI_SELECTED As Integer = 2
      Public Const LVNI_CUT As Integer = 4
      Public Const LVNI_DROPHILITED As Integer = 8
      Public Const LVNI_ABOVE As Integer = 256
      Public Const LVNI_BELOW As Integer = 512
      Public Const LVNI_TOLEFT As Integer = 1024
      Public Const LVNI_TORIGHT As Integer = 2048

      '--------------------------------------------------------------------------------------------------
      ' Extended List-View Styles
      Public Const LVS_EX_GRIDLINES As Integer = 1 ' Draws grid lines between items and sub-items.
      Public Const LVS_EX_SUBITEMIMAGES As Integer = 2 ' Allows images to be displayed for sub-items in report view.
      Public Const LVS_EX_CHECKBOXES As Integer = 4 ' Enables checkboxes next to items in any view.
      Public Const LVS_EX_TRACKSELECT As Integer = 8 ' Enables hot tracking (items are underlined when the mouse hovers).
      Public Const LVS_EX_HEADERDRAGDROP As Integer = 16 ' Enables drag-and-drop reordering of columns in report view.
      Public Const LVS_EX_FULLROWSELECT As Integer = 32 ' Selecting an item highlights the entire row (report view only).
      Public Const LVS_EX_FLATSB As Integer = 64 ' Obsolete. Enables flat scroll bars.
      Public Const LVS_EX_REGIONAL As Integer = 128 ' Creates a window region that includes only the pixels drawn for items.
      Public Const LVS_EX_INFOTIP As Integer = 1024 ' Enables tooltip information for items.
      Public Const LVS_EX_UNDERLINEHOT As Integer = 2048 ' Underlines hot-tracked items.
      Public Const LVS_EX_UNDERLINECOLD As Integer = 4096 ' Underlines non-hot-tracked items.
      Public Const LVS_EX_MULTIWORKAREAS As Integer = 8192 ' Enables multiple work areas in icon view.
      Public Const LVS_EX_LABELTIP As Integer = 16384 ' Draws tooltips for clipped labels if item text doesn't fit.
      Public Const LVS_EX_BORDERSELECT As Integer = 32768 ' Draws a border around focused items instead of highlighting.
      Public Const LVS_EX_DOUBLEBUFFER As Integer = 65536 ' Double-buffers the control to eliminate flickering during redraws.
      Public Const LVS_EX_HIDELABELS As Integer = 131072 ' Hides labels in icon and small icon view.
      Public Const LVS_EX_SINGLEROW As Integer = 262144 ' Unused.
      Public Const LVS_EX_SNAPTOGRID As Integer = 524288 ' Snaps icons to the grid in icon view.
      Public Const LVS_EX_SIMPLESELECT As Integer = 1048576 ' Simplifies selection (single click activates/selects).
      Public Const LVS_EX_JUSTIFYCOLUMNS As Integer = 2097152 ' Justifies columns in report view.
      Public Const LVS_EX_TRANSPARENTBKGND As Integer = 4194304 ' Requires themes. Draws a transparent background.
      Public Const LVS_EX_TRANSPARENTNOTEBOOK As Integer = 8388608 ' Requires themes. Not commonly used.
      Public Const LVS_EX_BUSINESSMODELS As Integer = 16777216 ' Applies alternate row colors (light/dark tinting).
      Public Const LVS_EX_SCALEICONGAP As Integer = 33554432 ' Scales the gap between icons based on DPI.
      Public Const LVS_EX_COLUMNRUMBLE As Integer = 67108864 ' Internal Windows use.
      Public Const LVS_EX_HEADERINALLVIEWS As Integer = 33554432 ' Displays the column header in all views, not just report view.

      '--------------------------------------------------------------------------------------------------
      ' Menu Flags
      Public Const MF_STRING As UInteger = &H0
      Public Const MF_SEPARATOR As UInteger = &H800

      ' Screen Metrics
      Public Const SM_CXSCREEN As Integer = 0
      Public Const SM_CYSCREEN As Integer = 1
      Public Const SM_CXVSCROLL As Integer = 2
      Public Const SM_CYHSCROLL As Integer = 3
      Public Const SM_CYCAPTION As Integer = 4
      Public Const SM_CXBORDER As Integer = 5
      Public Const SM_CYBORDER As Integer = 6
      Public Const SM_CXFIXEDFRAME As Integer = 7
      Public Const SM_CYFIXEDFRAME As Integer = 8
      Public Const SM_CYVSCROLL As Integer = 20
      Public Const SM_CXHSCROLL As Integer = 21
      Public Const SM_CMOUSEBUTTONS As Integer = 43
      Public Const SM_SWAPBUTTON As Integer = 23
      Public Const SM_MOUSEPRESENT As Integer = 19
      Public Const SM_SECURE As Integer = 44
      Public Const SM_SLOWMACHINE As Integer = 73
      Public Const SM_PENWINDOWS As Integer = 41
      Public Const SM_CXMIN As Integer = 28
      Public Const SM_CYMIN As Integer = 29
      Public Const SM_CXSIZE As Integer = 30
      Public Const SM_CYSIZE As Integer = 31
      Public Const SM_CXSIZEFRAME As Integer = 32
      Public Const SM_CYSIZEFRAME As Integer = 33
      Public Const SM_CXMINTRACK As Integer = 34
      Public Const SM_CYMINTRACK As Integer = 35
      Public Const SM_CXDOUBLECLK As Integer = 36
      Public Const SM_CYDOUBLECLK As Integer = 37
      Public Const SM_XVIRTUALSCREEN As Integer = 76
      Public Const SM_YVIRTUALSCREEN As Integer = 77
      Public Const SM_CXVIRTUALSCREEN As Integer = 78
      Public Const SM_CYVIRTUALSCREEN As Integer = 79
      Public Const SM_CMONITORS As Integer = 80
      Public Const SM_SAMEDISPLAYFORMAT As Integer = 81
      Public Const SM_CLEANBOOT As Integer = 67
      Public Const SM_MENUDROPALIGNMENT As Integer = 40
      Public Const SM_MIDEASTENABLED As Integer = 42
      Public Const SM_NETWORK As Integer = 63
      Public Const SM_SHOWSOUNDS As Integer = 70
      Public Const SM_DBCSENABLED As Integer = 38
      Public Const SM_CACABLES As Integer = 82
      Public Const SM_CHOOSEFONTORINFO As Integer = 83
      Public Const SM_CXCURSOR As Integer = 13
      Public Const SM_CYCURSOR As Integer = 14
      Public Const SM_CXDLGFRAME As Integer = 7
      Public Const SM_CYDLGFRAME As Integer = 8
      Public Const SM_CXDRAG As Integer = 68
      Public Const SM_CYDRAG As Integer = 69
      Public Const SM_CXEDGE As Integer = 45
      Public Const SM_CYEDGE As Integer = 46
      Public Const SM_CXFRAME As Integer = 32
      Public Const SM_CYFRAME As Integer = 33
      Public Const SM_CXFULLSCREEN As Integer = 16
      Public Const SM_CYFULLSCREEN As Integer = 17
      Public Const SM_CXHKEYBOARD As Integer = 65
      Public Const SM_CYHKEYBOARD As Integer = 66
      Public Const SM_CXICON As Integer = 11
      Public Const SM_CYICON As Integer = 12
      Public Const SM_CXICONSPACING As Integer = 38
      Public Const SM_CYICONSPACING As Integer = 39
      Public Const SM_CXKANJIWINDOW As Integer = 18
      Public Const SM_CYKANJIWINDOW As Integer = 18
      Public Const SM_CXMAXIMIZED As Integer = 61
      Public Const SM_CYMAXIMIZED As Integer = 62
      Public Const SM_CXMAXTRACK As Integer = 59
      Public Const SM_CYMAXTRACK As Integer = 60
      Public Const SM_CXMENUCHECK As Integer = 71
      Public Const SM_CYMENUCHECK As Integer = 72
      Public Const SM_CXMENUSIZE As Integer = 54
      Public Const SM_CYMENUSIZE As Integer = 55
      Public Const SM_CXMINIMIZED As Integer = 57
      Public Const SM_CYMINIMIZED As Integer = 58
      Public Const SM_CXMINSPACING As Integer = 47
      Public Const SM_CYMINSPACING As Integer = 48
      Public Const SM_CXSMICON As Integer = 49
      Public Const SM_CYSMICON As Integer = 50
      Public Const SM_CXSMSIZE As Integer = 52
      Public Const SM_CYSMSIZE As Integer = 53
      Public Const SM_CYSMCAPTION As Integer = 51
      Public Const SM_CXVIRTUALPC As Integer = 84
      Public Const SM_CYVIRTUALPC As Integer = 85
      Public Const SM_REMOTESESSION As Integer = 4096
      Public Const SM_SHUTTINGDOWN As Integer = 8192
      Public Const SM_STARTEREQUIV As Integer = 86
      Public Const SM_TABLETPC As Integer = 86
      Public Const SM_DIGITIZER As Integer = 94
      Public Const SM_MAXIMUMTOUCHES As Integer = 95
      Public Const SM_REMOTECONTROL As Integer = 8193
      Public Const SM_SYSTEMDOCKED As Integer = 8194

      '--------------------------------------------------------------------------------------------------
      ' SetWindowPos Flags
      Public Const SWP_NOSIZE As UInteger = &H1
      Public Const SWP_NOMOVE As UInteger = &H2
      Public Const SWP_NOACTIVATE As UInteger = &H10
      Public Const SWP_SHOWWINDOW As UInteger = &H40

      '--------------------------------------------------------------------------------------------------
      ' Window Message Constants

      ' 0 to 1023 (&H0 to &H3FF) : Messages reserved for the Windows Operating System
      Public Const WM_CREATE As Integer = &H1
      Public Const WM_DESTROY As Integer = &H2
      Public Const WM_CLOSE As Integer = &H10
      Public Const WM_QUERYENDSESSION As Integer = &H11
      Public Const WM_QUIT As Integer = &H12
      Public Const WM_ERASEBKGND As Integer = &H14
      Public Const WM_SETCURSOR As Integer = &H20
      Public Const WM_SETTEXT As Integer = &HC
      Public Const WM_GETTEXT As Integer = &HD
      Public Const WM_PAINT As Integer = &HF
      Public Const WM_KEYDOWN As Integer = &H100
      Public Const WM_KEYUP As Integer = &H101
      Public Const WM_CHAR As Integer = &H102
      Public Const WM_COMMAND As Integer = &H111
      Public Const WM_SYSCOMMAND As Integer = &H112
      Public Const WM_TIMER As Integer = &H113
      Public Const WM_MOUSEMOVE As Integer = &H200
      Public Const WM_LBUTTONDOWN As Integer = &H201
      Public Const WM_LBUTTONUP As Integer = &H202
      Public Const WM_RBUTTONUP As Integer = &H205

      ' 1024 to 32767 (&H400 to &H7FFF) :	Messages for use by private window classes
      Public Const WM_USER As Integer = &H400
      Public Const WM_TRAYICON As Integer = &H401

      ' 32768 to 49151 (&H8000 to &HBFFF) : Messages for use by applications

      ' 49152 to 65535 (&HC000 to &HFFFF) : Messages for use by the system

      '--------------------------------------------------------------------------------------------------
      ' Window Styles

      ''' <summary>The window has a thin-line border</summary>
      Public Const WS_BORDER As Integer = &H800000

      ''' <summary>The window has a title bar (includes WS_BORDER)</summary>
      Public Const WS_CAPTION As Integer = &HC00000

      ''' <summary> The window is a child window. Cannot be used with WS_POPUP</summary>
      Public Const WS_CHILD As Integer = &H40000000

      ''' <summary>Alias for WS_CHILD.</summary>
      Public Const WS_CHILDWINDOW As Integer = WS_CHILD

      ''' <summary>Excludes child windows from clipping regions.</summary>
      Public Const WS_CLIPCHILDREN As Integer = &H2000000

      ''' <summary>Clips sibling windows during drawing operations.</summary>
      Public Const WS_CLIPSIBLINGS As Integer = &H4000000

      ''' <summary>Disables the window.</summary>
      Public Const WS_DISABLED As Integer = &H8000000

      ''' <summary>The window has a dialog-style frame.</summary>
      Public Const WS_DLGFRAME As Integer = &H400000

      ''' <summary>The window is the first control in a group.</summary>
      Public Const WS_GROUP As Integer = &H20000

      ''' <summary>The window has a horizontal scroll bar.</summary>
      Public Const WS_HSCROLL As Integer = &H100000

      ''' <summary>The window is initially minimized.</summary>
      Public Const WS_ICONIC As Integer = &H20000000

      ''' <summary>The window is initially maximized.</summary>
      Public Const WS_MAXIMIZE As Integer = &H1000000

      ''' <summary>The window has a maximize button.</summary>
      Public Const WS_MAXIMIZEBOX As Integer = &H10000

      ''' <summary>The window is initially minimized.</summary>
      Public Const WS_MINIMIZE As Integer = &H20000000

      ''' <summary>The window has a minimize button.</summary>
      Public Const WS_MINIMIZEBOX As Integer = &H20000

      ''' <summary>A standard overlapped window (default).</summary>
      Public Const WS_OVERLAPPED As Integer = &H0

      ''' <summary>The window is a pop-up window. Cannot be used with WS_CHILD.</summary>
      Public Const WS_POPUP As Integer = &H80000000

      ''' <summary>The window has a sizing border.</summary>
      Public Const WS_SIZEBOX As Integer = &H40000

      ''' <summary>The window has a system menu.</summary>
      Public Const WS_SYSMENU As Integer = &H80000

      ''' <summary>The control can receive keyboard focus via TAB.</summary>
      Public Const WS_TABSTOP As Integer = &H10000

      ''' <summary>Alias for WS_SIZEBOX.</summary>
      Public Const WS_THICKFRAME As Integer = WS_SIZEBOX

      ''' <summary>Alias for WS_OVERLAPPED.</summary>
      Public Const WS_TILED As Integer = WS_OVERLAPPED

      ''' <summary>The window is initially visible.</summary>
      Public Const WS_VISIBLE As Integer = &H10000000

      ''' <summary>The window has a vertical scroll bar.</summary>
      Public Const WS_VSCROLL As Integer = &H200000


      '--------------------------------------------------------------------------------------------------
      ' Extended Window Styles

      ''' <summary>The window accepts drag-drop files.</summary>
      Public Const WS_EX_ACCEPTFILES As Integer = &H10

      ''' <summary>Forces a top-level window onto the taskbar when the window is visible.</summary>
      Public Const WS_EX_APPWINDOW As Integer = &H40000

      ''' <summary>The window has a border with a sunken edge.</summary>
      Public Const WS_EX_CLIENTEDGE As Integer = &H200

      ''' <summary>Paints all descendants of a window in bottom-to-top painting order using double-buffering.</summary>
      Public Const WS_EX_COMPOSITED As Integer = &H2000000

      ''' <summary>The title bar includes a question mark. Cannot be used with maximize/minimize buttons.</summary>
      Public Const WS_EX_CONTEXTHELP As Integer = &H400

      ''' <summary>The window itself contains child windows that should take part in dialog box navigation.</summary>
      Public Const WS_EX_CONTROLPARENT As Integer = &H10000

      ''' <summary>The window has a double border.</summary>
      Public Const WS_EX_DLGMODALFRAME As Integer = &H1

      ''' <summary>The window is a layered window. Required for transparency/alpha effects.</summary>
      Public Const WS_EX_LAYERED As Integer = &H80000

      ''' <summary>If the shell language is Hebrew/Arabic, the horizontal origin is on the right edge.</summary>
      Public Const WS_EX_LAYOUTRTL As Integer = &H400000

      ''' <summary>The window has generic left-aligned properties. This is the default.</summary>
      Public Const WS_EX_LEFT As Integer = &H0

      ''' <summary>The vertical scroll bar is to the left of the client area (RTL languages).</summary>
      Public Const WS_EX_LEFTSCROLLBAR As Integer = &H4000

      ''' <summary>The window text is displayed using left-to-right reading-order properties.</summary>
      Public Const WS_EX_LTRREADING As Integer = &H0

      ''' <summary>The window is a MDI child window.</summary>
      Public Const WS_EX_MDICHILD As Integer = &H40

      ''' <summary>A top-level window that does not become the foreground window when clicked.</summary>
      Public Const WS_EX_NOACTIVATE As Integer = &H8000000

      ''' <summary>The window does not pass its window layout to its child windows.</summary>
      Public Const WS_EX_NOINHERITLAYOUT As Integer = &H100000

      ''' <summary>The child window does not send the WM_PARENTNOTIFY message to its parent.</summary>
      Public Const WS_EX_NOPARENTNOTIFY As Integer = &H4

      ''' <summary>The window does not render to a redirection surface. Use for Acrylic/Composition.</summary>
      Public Const WS_EX_NOREDIRECTIONBITMAP As Integer = &H200000

      ''' <summary>The window has generic "right-aligned" properties (RTL languages).</summary>
      Public Const WS_EX_RIGHT As Integer = &H1000

      ''' <summary>The vertical scroll bar is to the right of the client area. This is the default.</summary>
      Public Const WS_EX_RIGHTSCROLLBAR As Integer = &H0

      ''' <summary>The window text is displayed using right-to-left reading-order properties.</summary>
      Public Const WS_EX_RTLREADING As Integer = &H2000

      ''' <summary>The window has a 3D border style for items that do not accept user input.</summary>
      Public Const WS_EX_STATICEDGE As Integer = &H20000

      ''' <summary>The window is intended to be used as a floating toolbar (no taskbar icon).</summary>
      Public Const WS_EX_TOOLWINDOW As Integer = &H80

      ''' <summary>The window should be placed above all non-topmost windows.</summary>
      Public Const WS_EX_TOPMOST As Integer = &H8

      ''' <summary>The window should not be painted until siblings beneath it are painted.</summary>
      Public Const WS_EX_TRANSPARENT As Integer = &H20

      ''' <summary>The window has a border with a raised edge.</summary>
      Public Const WS_EX_WINDOWEDGE As Integer = &H3C

      ' --- Combined Styles ---

      ''' <summary>Combines WS_EX_WINDOWEDGE and WS_EX_CLIENTEDGE.</summary>
      Public Const WS_EX_OVERLAPPEDWINDOW As Integer = (WS_EX_WINDOWEDGE Or WS_EX_CLIENTEDGE)

      ''' <summary>Combines WS_EX_WINDOWEDGE, WS_EX_TOOLWINDOW, and WS_EX_TOPMOST.</summary>
      Public Const WS_EX_PALETTEWINDOW As Integer = (WS_EX_WINDOWEDGE Or WS_EX_TOOLWINDOW Or WS_EX_TOPMOST)

      '--------------------------------------------------------------------------------------------------
      ' Get Window Long Styles

      Public Const GWL_STYLE As Integer = -16

   End Module

End Namespace