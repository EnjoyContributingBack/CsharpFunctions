This is custom application for file copy function using the several filter criteria.
-----------------------------------------------------------------------------------
Comments generated by ChatGPT3.5 for main copy functionsas follows....
-------------------------------------------------
string[] files = Directory.GetFiles(srcFolder, uExt, SearchOption.AllDirectories);
This line retrieves an array of file paths that match the specified extension (uExt) in the source directory (srcFolder) and its subdirectories.

foreach (string uFile in files) { ... }
This loop iterates through each file path in the array obtained in the previous step.

string ufileName = Path.GetFileName(uFile);
This line extracts the file name from the full path.

The next section of code checks whether to copy the file based on certain conditions:
a. if (!copyAll) { ... }: If copyAll is false, the code checks additional conditions before deciding whether to copy the file.
b. Inside this block, there is another loop (foreach (string uf in ufilters) { ... }) that iterates through a list of filters (ufilters). 
	It checks if the file name contains any of the specified filters.
c. If the file name contains a filter and certain conditions are met, the file is marked for copying (blnCopy = true) and the loop is exited.
d. If blnCopy is false after the inner loop, the outer loop continues to the next file.

string destPath = destFolder + "\\" + ufileName;
Constructs the destination path for the file in the destination folder (destFolder).
if (File.Exists(destPath)) continue;
If the file already exists in the destination folder, it skips to the next iteration of the loop, avoiding overwriting.

File.Copy(uFile, destPath, true);
Copies the file from the source path (uFile) to the destination path (destPath). 
The true parameter indicates that the file should be overwritten if it already exists in the destination.

In summary, this code iterates through files in a source folder and its subdirectories, checks certain conditions for each file, 
and copies it to a destination folder if the conditions are met. It avoids overwriting existing files in the destination folder unless explicitly allowed. 
The status of the operation is updated in a label (lblStatus)