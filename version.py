import sys
import json
import os

build = 0
if len(sys.argv) > 1:
    build = int(sys.argv[1])

# read data out of the version file
with open('KCTR.version') as f:
    data = json.load(f)

ver = data['VERSION']
data['VERSION']['BUILD'] = build
fullVer = f"{ver['MAJOR']}.{ver['MINOR']}.{ver['PATCH']}.{build}"
print(f'Version: {fullVer}')

# write back to the version file with the updated build number
with open('KCTR.version', 'w') as f:
    json.dump(data, f, indent=2)

with open('version.txt', 'w') as f:
    f.write(f'{fullVer}\n')

# write to the version.cs file with the updated version
with open('KCTR/Properties/VersionInfo.cs', 'w') as f:
    f.write('using System.Reflection;\n')
    f.write(f'[assembly: AssemblyFileVersion("{fullVer}")]\n')

print('Versioning complete.')