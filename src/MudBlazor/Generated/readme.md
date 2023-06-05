MudBlazor.SourceCodeGenerator.FastEnumDescriptionGenerator

was done with:

add 

  <PropertyGroup>
    <!-- Persist the source generator (and other) files to disk -->
    <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
    <!-- 👇 The "base" path for the source generators -->
    <GeneratedFolder>Generated</GeneratedFolder>
    <!-- 👇 Write the output for each target framework to a different sub-folder -->
    <CompilerGeneratedFilesOutputPath>$(GeneratedFolder)\$(TargetFramework)</CompilerGeneratedFilesOutputPath>
  </PropertyGroup>
  <ItemGroup>
    <!-- Exclude the output of source generators from the compilation -->
    <Compile Remove="$(CompilerGeneratedFilesOutputPath)/**/*.cs" />
  </ItemGroup>

to 
MudBlazor.csproj

and compile with
dotnet 7.0 installed

then copy the files to the above directory
