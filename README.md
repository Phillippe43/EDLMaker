# EDLMaker

#Create EDL files for smplayer easily.

# What is an EDL file? 
An EDL file or "Edit Decision List" allows you to automatically skip or mute sections of videos during playback, based on a movie specific EDL configuration file.


# What It Does
Mutes:
This program will scan through an .srt (subtitle) file against a list of bad words that can be modified by the user. It will create an .edl file that is formatted for SMPlayer with the same name as the .srt file. Updated, another text file is created that contains all the times and subtitles that are blocked, so you can double check to see if you really want something muted or not, becuase context is everything. 

Cut/Skip Scenes:
Unfortunately I know of no easy way to include cutscenes automatically, so that will have to be done by the user. However, I tried to make the process as easy as possible. The user will create a txt file and enter in the start time and end time for the scenes they wish to skip, one line per skip scene. Once done, use this program to merge the manual cutscene file with the .edl file that was created. The program will convert the times into seconds and add the skip scene flag at the end of each line and then sort by times.

Time Adjust:
The usage of the .edl file by the computer will almost always be off a little. The program has the ability to adjust the start and end times separately from any number of seconds to milliseconds. The adjustment will effect all start times and/or all end times. 

I know KODI already has an addon for this, but I like to watch movies with better qualtiy than the KODI engine can produce.

Sensible Cinema is a good program but it's EDL files won't work with SMPlayer. 
