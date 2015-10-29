##LAWN MOWERS
A fleet of robotic lawn mowers are to be deployed to trim the grass of a large lawn. This lawn, which is perfectly rectangular, must be navigated by the mowers so that they can maintain an even height of grass. The lawn is bordered on all sides by gardens that contain rare plants.

A mower's position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The lawn is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the mower is in the bottom left corner and facing North.

In order to control a mower, the remote controller sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the mower spin 90 degrees left or right respectively, without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).

###INPUT
The first line of input is the upper-right coordinates of the lawn, the lower-left coordinates are assumed to be 0,0.

The rest of the input is information pertaining to the mowers that have been deployed. Each mower has two lines of input. The first line gives the mower's position, and the second line is a series of instructions telling the mower how to explore the lawn.

The position is made up of two integers and a letter separated by spaces, corresponding to the x and y co-ordinates and the mower's orientation.
Each mower will be finished sequentially, which means that the second mower won't start to move until the first one has finished moving.

###OUTPUT
The output for each mower should be its final co-ordinates and heading.
INPUT AND OUTPUT

####Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
####Expected Output:
1 3 N
5 1 E