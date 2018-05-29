namespace Public
{
    public static class Messages
    {
        public const string EmptyFile = "Maze generation failed: The file is empty.";
        public const string InvalidLines = "Maze generation failed: The lines of the file are not at the same length.";
        public const string InvalidBlock = "Maze generation failed: The block '{0}' is not a valid notation.";
        public const string NoGoal = "Maze generation failed: the maze does not have Goal node.";
        public const string NoStart = "Maze generation failed: the maze does not have Start node";
        public const string UniqueGoal = "Maze generation failed: the maze must have only one Goal node.";
        public const string UniqueStart = "Maze generation failed: the maze must have only one Start node";
    }

}
