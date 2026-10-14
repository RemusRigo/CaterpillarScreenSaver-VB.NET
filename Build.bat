color 02
dotnet restore

@timeout 3

rem dotnet build -f net48 -c Release -p:Platform=x64 -p:DebugType=None -p:DebugSymbols=false
rem dotnet build -f net48 -c Release -p:Platform=x86 -p:DebugType=None -p:DebugSymbols=false

dotnet build -f net8.0-windows -c Release -p:Platform=x64 -p:DebugType=None -p:DebugSymbols=false
dotnet build -f net8.0-windows -c Release -p:Platform=x86 -p:DebugType=None -p:DebugSymbols=false

dotnet build -f net10.0-windows -c Release -p:Platform=x64 -p:DebugType=None -p:DebugSymbols=false
dotnet build -f net10.0-windows -c Release -p:Platform=x86 -p:DebugType=None -p:DebugSymbols=false

copy *.md .\bin\Release /Y
copy *.txt .\bin\Release /Y

@timeout 7