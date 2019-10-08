# rvaccine
## Poor Man`s Ransomware Vaccine

This little project was made to provide a workaround to prevent infections from ransomware. You can even use it as an enterprise wide *vaccine* in case of a known outbreak like Wannacry or the next wave of Emotet/ Trickbot. 

Still a lot of exe files are used to infect machines, not only scripts in Powershell or WMI. The execution of *known* exe files can be prevented by using the *Debugger* entry in the local registry of a Windows operating system. Again, you *must* know the name of the executable file you want to block. Otherwise this workaround will fail.

You have to write a key to the registry of all you clients, where the name of the key under "Image File Execution Options" must be the known name of the malware. Let`s assume the name is *malware.exe* then you need to create this key
**\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\malware.exe**

Then create a REG_SZ string with the name Debugger and as its value enter the path to rvaccine.exe. That is all!
You can test it easily with a key name like *notepad.exe* and the path to rvaccine.exe. Once the key is set, you cannot execute Notepad  and longer.

Once an exe file with a - lets say - Emotet dropper is double-clicked by one of your users, the file rvaccine.exe acts as a Debugger and does nothing more than creating a unique entry in your local Application log with a the predefined text *Potentail Ransomware Event* and the  Event ID 765. The code from the malware will not be executed and the started malicious exe file silently stopped from doing any harm. Any good running SIEM then allows you to create rules for monitoring Event ID 765.

In which scenarios does this all make sense?
- there is an outbreak and your Threat Intelligence partner gave you the name of the dropper that encrypts the files
- you got the name of the ransomware dropper as a result of your own host-based forensic analysis
- parts of your Windows network are already encrypted and you want to vaccine the remaining endpoints before you reconnect


## The Deployment Part

The file rvaccine.exe must be in %PATH% to be found- sorry. 
Putting it somewhere in C:\Program Files\ does not make sense, it should go to %SYSTEMROOT%\System32\. 
Deploy it via
1. SCCM or any other Endpoint Management software (preferred solution) or 
2. as part of your login script in Active Directory or
3. by hand from your workstation when 1. and 2. are not posssible for any reason



## Idea
This project is based on an idea from Florian Roth
