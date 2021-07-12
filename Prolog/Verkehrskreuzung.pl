% In the following program, a traffic intersection with four entrances is declared.
% The program offers the possibility to query whether a car is allowed to pass the intersection or whether other cars have priority
% Author:   Fabian Lorenz
% Date:     08.07.2021

% Traffic intersection declaration with direction for the four driveways. 
% 'none' as direction if there is no car parked at this driveway.
car(top,right).
car(left,straight).
car(right,right).
car(bottom,left).

% for each driveway the entrance at the right
rightOf(top,left).
rightOf(left,bottom).
rightOf(bottom,right).
rightOf(right,top).

% for each driveway the driveway opposite
straightTo(top,bottom).
straightTo(bottom,top).
straightTo(right,left).
straightTo(left,right).

% allowed combinations for cars on the right
allowedCombinationRight(right,straight).
allowedCombinationRight(right,right).
allowedCombinationRight(left,right).

%%% if there is no car, everthing is allowed
allowedCombinationRight(right,none).
allowedCombinationRight(left,none).
allowedCombinationRight(straight,none).

% allowed combinations for cars opposite
allowedCombinationStraight(straight,straight).
allowedCombinationStraight(straight,right).
allowedCombinationStraight(straight,left).
allowedCombinationStraight(right,straight).
allowedCombinationStraight(right,left).
allowedCombinationStraight(right,right).
allowedCombinationStraight(left,left).

%%% if there is no car, everything is allowed
allowedCombinationStraight(right,none).
allowedCombinationStraight(left,none).
allowedCombinationStraight(straight,none).

% Checks, if it´s allowed to drive with the car on the opposite
mayDriveStraight(X):-straightTo(X,Y),car(X,A),car(Y,B),allowedCombinationStraight(A,B).

% Checks, if it´s allowed to drive with the car on the right
mayDriveRight(X):-rightOf(X,Y),car(X,A),car(Y,B),allowedCombinationRight(A,B).

% Checks,if it´s allowed to drive by checking if straight AND right is allowed. 
% Returns true or false, whether the car is allowed to drive or not.
mayDrive(X):-mayDriveRight(X),mayDriveStraight(X).



