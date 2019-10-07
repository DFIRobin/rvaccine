# rvaccine
## Poor Man`s Ransomware Vaccine

This little project was made to provide a workaround to prevent infections from ransomware. You can even use it as an enterprise wide *vaccine* in case of a known outbreak like Wannacry or the next wave of Emotet/ Trickbot. 

Still a lot of exe files are used to infect machines, not only scripts in Powershell or WMI. The execution of *known* exe files can be prevented by using the *Debugger* entry in the local regsitry of a Windows operating system. Again, you **must** know the name of the executable file you want to block. Otherwise this workaround will fail.

Once an exe file with a - lets say - Emotet dropper is double-clicked by one of your users, the file rvaccine.exe acts as a Debugger and does nothing more than creating a unique entry in your local Application log with a the predefined text *Potentail Ransomware Event* and the  Event ID 765. The code from the malware will not be executed and the started malicious exe file silently stopped from doing any harm.

Any good running SIEM then allows you to create rules for monitoring Event ID 765.
