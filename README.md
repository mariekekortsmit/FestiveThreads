# FestiveThreads: Christmas Tree Light Synchronization Simulator

## Overview
FestiveThreads is a console application that simulates a Christmas tree light display synchronized to CPU usage. This application leverages multiple threads, each controlling a light on the tree, reflecting real-time CPU utilization.

## Features
- **Real-Time CPU Monitoring**: Dynamically monitors CPU usage and reflects it through the light display.
- **Multi-Core Utilization**: Simulates each light with a separate thread, representing individual CPU cores.
- **Interactive Tree Display**: A visual representation of a Christmas tree with lights that change based on CPU activity.
- **Cross-Platform Compatibility**: Works on both Windows and non-Windows environments, adapting to the available system resources.

## Requirements
- .NET Core or .NET Framework compatible environment
- For Windows: Access to Windows Management Instrumentation (WMI) for CPU data

## Installation
1. Clone or download the repository.
2. Open the solution in Visual Studio or your preferred .NET IDE.
3. Build the solution to restore NuGet packages and compile the application.

## Usage
Run the application, and it will display a Christmas tree in the console window. Each light on the tree represents a CPU core, and the lights will change (blink) according to the CPU usage detected by the application.

## Components
1. **Program**: The main entry point that initializes core count and starts light controllers.
2. **CpuUsageMonitor**: Handles real-time CPU usage monitoring.
3. **LightDisplay**: Manages the visual display of the Christmas tree and lights.
4. **LightController**: Controls individual lights, simulating CPU core activities.

## Notes
- The application runs an infinite loop to continually update the display. Use `Ctrl+C` to exit.
- CPU usage detection might vary based on the operating system and available system resources.
