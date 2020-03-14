
class Read_CSV():
    def __init__(self):
        self._path = 'data.csv'
        self._data = self.read()

    def get_data(self):
        return self._data

    def read(self):
        import csv
        with open(self._path, 'r') as fin:
            #data = csv.reader(fin)
            data = csv.DictReader(fin, fieldnames=['PartNumber', 'Level', 'RevNo'])
            return [row for row in data]

class PartsStructuresBuilder():
    def __init__(self, partsDict):
        partsDict = self._addEmptyList(partsDict)
        maxLevel = self._getLevelMax(partsDict)
        self._partsStructure = self._makeStructures(maxLevel, partsDict)

    def get_Structure(self):
        return self._partsStructure

    def _makeStructures(self, maxLevel, partsDict):
        parentPart = partsDict[0]

        for level in range(maxLevel,0,-1):
            tmp = []
            for part in partsDict:
                if level == int(part['Level']):
                    parentPart['child'].append(part)
                else:
                    parentPart = part
                    tmp.append(part)
            partsDict = tmp
        return parentPart

    def _getLevelMax(self, partsDict):
        level = 0
        for parts in partsDict:
            currentLevel = int(parts['Level'])
            if level < currentLevel:
                level = currentLevel
        return level

    def _addEmptyList(self, partsDict):
        for part in partsDict:
            part['child'] = []
        return partsDict





csvReader = Read_CSV()
partsDict = csvReader.get_data()
builder = PartsStructuresBuilder(partsDict)
structure = builder.get_Structure()

print('test')