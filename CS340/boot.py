import pandas as pd
from CRUD_MODULE_V3 import DataBaseObjectLayer

def main():
    x = DataBaseObjectLayer('test', 'test', 'animals', 27017)
    df = pd.DataFrame.from_records(x.read({}, 'animals'))

if __name__ == "__main__":
    main()