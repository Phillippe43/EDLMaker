# EDLMaker
Create EDL files for mplayer easily.

I know KODI already has an addon for this, but I like to watch movies with better qualtiy than the KODI engine can produce.

Sensible Cinema is a good program but it's EDL files won't work with MPlayer. 

# What It Does
Mutes:
This program will scan through an .srt file and against a list of bad words that can be modified by the user. It will create an .edl file with the same name as the .srt file that is formatted for MPlayer. 

Cut/Skip Scenes:
Unfortunately I know of no easy way to include cutscenes automatically, so that will have to be done by the user. However, I tried to make the process as easy as possible. The user will create a txt file and enter in the start time and end time for the scenes they wish to skip, one line per skip scene. Once done, use this program to merge the manual cutscene file with the .edl file that was created. The program will convert the times into seconds and add the skip scene flag at the end of each line and then sort by times.
