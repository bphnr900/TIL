
from graphviz import Digraph

# CSVからデータを読み取る
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

# 部品をツリー状に変換する
class PartsStructuresBuilder():
    def __init__(self):
        self._rawData = self._getData()
        partsDict = self._addEmptyList(self._rawData)
        maxLevel = self._getLevelMax(partsDict)
        self._partsStructure = self._makeStructures(maxLevel, partsDict)

    def get_Structure(self):
        return self._partsStructure

    def get_rawData(self):
        return self._rawData

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

    def _getData(self):
        csvReader = Read_CSV()
        return csvReader.get_data()

# graphvizを使って線をひく
class TreePainter():
    def __init__(self):
        self._dot = Digraph(comment='Sample',graph_attr={'rankdir':'LR','fontname':'Segoe UI'},edge_attr={'dir':'none'})

        builder = PartsStructuresBuilder()
        # アイテムを追加
        self._addNode(builder.get_rawData())
        # アイテム間で線をひく
        self._addEdges(builder.get_Structure())

    def get_dot(self):
        return self._dot

    def _addNode(self, structure):
        for part in structure:
            self._dot.node(part['PartNumber'],label=part['PartNumber'],shape='box')

    def _addEdges(self, structure):
        edge = []
        edge = self._makeEdge(structure, edge)
        self._dot.edges(edge)

    def _makeEdge(self, structure, edge):
        for part in structure['child']:
            edge.append(structure['PartNumber'] + part['PartNumber'])
            if len(part['child']) > 0:
                edge = self._makeEdge(part, edge)
        return edge

if __name__ == "__main__":
    TreePainter = TreePainter()
    dot = TreePainter.get_dot()

    dot.render('test-output/round-table.gv', view=True)

    print('test')