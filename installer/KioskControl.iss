#define AppName "KioskControl"
#ifndef MyAppVersion
  #define MyAppVersion "0.1.0"
#endif

[Setup]
AppId={{D91B92C2-1E18-4A3F-92B7-1D6A7B0C2E11}
AppName={#AppName}
AppVersion={#MyAppVersion}
AppPublisher=KioskControl
DefaultDirName={autopf}\KioskControl
DefaultGroupName=KioskControl
OutputDir=output
OutputBaseFilename=KioskControl-Setup
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
PrivilegesRequired=admin
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\KioskControl.exe
Compression=lzma2
SolidCompression=yes
WizardStyle=modern

[Files]
Source: "..\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\KioskControl"; Filename: "{app}\KioskControl.exe"
Name: "{autodesktop}\KioskControl"; Filename: "{app}\KioskControl.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "יצירת קיצור דרך בשולחן העבודה"; GroupDescription: "קיצורי דרך:"

[Run]
Filename: "{app}\KioskControl.exe"; Description: "הפעלת KioskControl"; Flags: postinstall nowait skipifsilent
